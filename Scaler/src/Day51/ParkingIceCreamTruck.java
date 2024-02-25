package Day51;

import java.util.ArrayList;
import java.util.Deque;
import java.util.LinkedList;
import java.util.List;

public class ParkingIceCreamTruck {

	public static void main(String[] args) {
		int B = 6;
		List<Integer> list = new LinkedList<Integer>();
		list.add(1);
		list.add(2);
		list.add(3);
		list.add(4);
		list.add(2);
		list.add(7);
		list.add(1);
		list.add(3);
		list.add(6);
		
		ArrayList<Integer> ans = slidingMaximum(list, B);
		printElement(ans);
	}
	public static ArrayList<Integer> slidingMaximum(final List<Integer> A, int B) {
        int n = A.size();
        ArrayList<Integer> ans = new ArrayList<>();
        Deque<Integer> dq = new LinkedList<>();
       
        for(int i=0;i<B;i++){
            while(dq.size()>0 && dq.peekLast()<A.get(i)){
                dq.removeLast();
            }
            dq.addLast(A.get(i));
        }
        ans.add(dq.peekFirst());

        for(int i=B;i<n;i++){
            while(dq.size()>0 && dq.peekLast()<A.get(i)){
                dq.removeLast();
            }
            dq.addLast(A.get(i));

            if(dq.peekFirst() == A.get(i-B)){
                dq.removeFirst();
            }
            ans.add(dq.peekFirst());
        }
        return ans;
    }
	public static void printElement(ArrayList<Integer> ans) {
		for (int i =0; i < ans.size(); i++) {
			System.out.print(ans.get(i) + " ");
		}
	}
}
