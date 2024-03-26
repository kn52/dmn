package Day62;

import java.util.*;

public class FlipkartsChallengeinEffectiveInventoryManagement {

	public static void main(String[] args) {
		// TODO Auto-generated method stub

	}

	public int solve(int[] A, int[] B) {
		int mod = 1000000007;
		ArrayList<Merge> arr = new ArrayList<Merge>();
		for (int i = 0; i < A.length; i++) {
			arr.add(new Merge(A[i], B[i]));
		}

		// sorting based on the exp date
		Collections.sort(arr, new Sortexpdate());

		PriorityQueue<Integer> minHeap = new PriorityQueue<>();
		int time = 0;
		for (int i = 0; i < arr.size(); i++) {
			if (time < arr.get(i).expDate) {
				minHeap.add(arr.get(i).profit);
				time++;
			} else {
				if (arr.get(i).profit > minHeap.peek()) {
					minHeap.remove();
					minHeap.add(arr.get(i).profit);

				}
			}
		}

		long ans = 0;
		Iterator<Integer> temp = minHeap.iterator();

		while (temp.hasNext()) {
			ans = (ans + temp.next()) % mod;
		}

		return (int) ans;

	}

	class Merge {
		int expDate;
		int profit;

		public Merge(int expDate, int profit) {
			this.expDate = expDate;
			this.profit = profit;
		}
	}

	class Sortexpdate implements Comparator<Merge> {

		public int compare(Merge A, Merge B) {

			return A.expDate - B.expDate;

		}
	}
}
