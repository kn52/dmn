package Day60;

public class MinAHeap {

	public static void main(String[] args) {
		// TODO Auto-generated method stub
		int[] A = new int[1];
		int N = A.length;
		for (int i = (N-2)/2; i>=0; i--) {
			heapify(A, i);
		}
	}

	
	public static void heapify(int[] arr, int i) {
		int N = arr.length;
		
		int leftchild = arr[2*i+1];
		int rightchild = (2*i+2 < N) ? arr[2*i+2] : -1;
		
		while (i < N) {
			int minchild = Math.min(leftchild, rightchild);
			int min = Math.min(minchild, arr[i]);
			if (min == leftchild) {
				int temp = leftchild;
				arr[2*i + 1] = arr[i];
				arr[i] = temp;
				i= 2*i+1;
			}
			else if (min == rightchild) {
				int temp = rightchild;
				arr[2*i + 2] = arr[i];
				arr[i] = temp;
				i= 2*i+2;
			}
			else {
				break;
			}
		}
	}
}
